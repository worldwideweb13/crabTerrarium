using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ヤドカリの挙動管理
/// </summary>
public class CrabController : MonoBehaviour
{
    /// <summary>
    /// ヤドカリの移動地点
    /// </summary>
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;

    enum State
    {
        MoveToPoint1,
        StopOnPoint1,
        MoveToPoint2,
        StopOnPoint2,
    }


    State currentState = State.MoveToPoint1;
    /// <summary>
    /// stateEnter...進行方向の変更管理フラグ
    /// </summary>
    bool stateEnter = false;

    float stateTime = 0f;


    /// <summary>
    /// stateの変更関数
    /// </summary>
    void ChangeState(State newState)
    {
        currentState = newState;
        stateEnter = true;
        stateTime = 0f;
    }

    /// <summary>
    /// ヤドカリの進行方向制御に利用するコンポーネント
    /// </summary>
    NavMeshAgent navMeshAgent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        stateTime += Time.deltaTime;

        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("HermitCrabSpeed", speed);

        switch (currentState)
        {
            case State.MoveToPoint1:
                {
                    /// ヤドカリがPoint1に動く直前に進行方向をセット
                    if (stateEnter)
                    {
                        navMeshAgent.SetDestination(point1.position);
                    }
                    /// ヤドカリがPoint1に到着したら、Stopアクションに移行
                    if(navMeshAgent.remainingDistance <= 0.01f && !navMeshAgent.pathPending)
                    {
                        ChangeState(State.StopOnPoint1);
                        return;
                    }
                    return;
                }
            case State.StopOnPoint1:
                if(stateTime >= 3f)
                {
                    ChangeState(State.MoveToPoint2);
                    return;
                }
                return;

            case State.MoveToPoint2:
                {
                    if (stateEnter)
                    {
                        navMeshAgent.SetDestination(point2.position);
                    }
                    if(navMeshAgent.remainingDistance <= 0.01f && !navMeshAgent.pathPending)
                    {
                        ChangeState(State.StopOnPoint2);
                        return;
                    }
                    return;
                }
            case State.StopOnPoint2:
                if (stateTime >= 3f)
                {
                    ChangeState(State.MoveToPoint1);
                    return;
                }
                return;
        }        
    }

    /// <summary>
    /// stateが切り替わった次の１フレームのみnavMeshAgent.SetDestination()を実行
    /// </summary>
    private void LateUpdate()
    {
        if(stateTime != 0)
        {
            stateEnter = false;
        }
    }

}
