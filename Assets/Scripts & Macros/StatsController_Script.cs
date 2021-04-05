using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum JobRoles
{
    Gatherer,
    Collector,
    Distributer,
    Controller
} 
public class StatsController_Script : MonoBehaviour
{
    [Header("Entity Name")]
    public string name;

    [Header("Entity Stats")]
    private float healthStat = 100;
    public Slider healthBar;

    private float hungerStat = 100;
    public Slider hungerBar;

    private float thirstStat = 100;
    public Slider thirstBar;

    private float energyStat = 100;
    public Slider energyBar;

    [Header("Entity Work Stats")]
    public Transform workPlace;
    public Transform clientWorkplace;
    public GameObject workItem;

    public JobRoles jobRoles;

    [Header("Entity Stat Decay Rate")]
    public float decayRate;

    Animator state;
    public StateMachine_Script stateMachine;
    public IdleState_Script idling;
    public MovementState_Script wandering;

    private void Awake()
    {
        state = GetComponent<Animator>();

        stateMachine = new StateMachine_Script();

        idling = new IdleState_Script(this, stateMachine);
        wandering = new MovementState_Script(this, stateMachine);

        stateMachine.Initialize(idling);
    }

    void Update()
    {
        UpdateDebugText();
        NeedsDecay();
        //stateMachine.CurrentState.HandleInput();
    }

    public void NeedsDecay()
    {
        if (healthStat > 0)
        {
            hungerStat -= Time.deltaTime / decayRate;
            state.SetFloat("Hunger", hungerStat);
            thirstStat -= Time.deltaTime / decayRate;
            state.SetFloat("Thirst", hungerStat);
            energyStat -= Time.deltaTime / decayRate / 2;
            state.SetFloat("Energy", hungerStat);
        }
    }

    public void AssignWorkplace(Transform _workPlace)
    {
        workPlace = _workPlace;
    }

    public void AssignCollectionPoint(Transform _collectionPoint)
    {
        clientWorkplace = _collectionPoint;
    }

    public void AssignWorkItem(GameObject _workItem)
    {
        workItem = _workItem;
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }

    void UpdateDebugText()
    {
        thirstBar.value = thirstStat;
        hungerBar.value = hungerStat;
        energyBar.value = energyStat;
    }
}
