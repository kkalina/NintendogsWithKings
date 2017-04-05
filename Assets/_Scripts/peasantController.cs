using UnityEngine;
using System.Collections;

public class peasantController : MonoBehaviour {

    public bool Assassin = false;
    public float assassinOffset = 5;
    public Material assassinMat;
    public GameObject characterMesh;
    public GameObject king;
    public GameObject assassinExplosion;

    public float chanceToBecomeAssassinOneIn = 100;

    public float peasantSpeed = 3.5f;
    public float assassinSpeed = 5.5f;

    private Vector3 goal;
    private UnityEngine.AI.NavMeshAgent navi;
    public float max_walk_distance = 50f;
    public float directionChangeInterval = 5f;
    private float timeOfLastDirectionChange = 0f;

    void Start ()
    {
        king = GameObject.Find("King");
        navi = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (Assassin)
        {
            navi.speed = assassinSpeed;
            characterMesh.GetComponent<Renderer>().material = assassinMat;
            //goal = new Vector3(Random.Range(king.transform.position.x - assassinOffset, king.transform.position.x + assassinOffset), king.transform.position.y, Random.Range(king.transform.position.z - assassinOffset, king.transform.position.z + assassinOffset));
            goal = king.transform.position;
            navi.SetDestination(goal);
            timeOfLastDirectionChange = Time.time;
        }
        else
        {

            navi.speed = peasantSpeed;
            //pick random destination
            Vector3 direction = Random.insideUnitSphere * max_walk_distance;
            direction += transform.position;
            UnityEngine.AI.NavMeshHit hit;
            UnityEngine.AI.NavMesh.SamplePosition(direction, out hit, Random.Range(1f, max_walk_distance), 1);
            timeOfLastDirectionChange = Time.time;
            goal = hit.position;
            navi.SetDestination(goal);
        }
    }
	
	void Update () {

        if (Assassin) {
            if (Time.time > (timeOfLastDirectionChange + directionChangeInterval))
            {
                //goal = new Vector3(Random.Range(king.transform.position.x - assassinOffset, king.transform.position.x + assassinOffset), king.transform.position.y, Random.Range(king.transform.position.z - assassinOffset, king.transform.position.z + assassinOffset));
                goal = king.transform.position;

                navi.SetDestination(goal);
                timeOfLastDirectionChange = Time.time;
            }
            float kingDist = Vector3.Distance(this.transform.position, king.transform.position);
            if (kingDist < 3)
            {
                king.gameObject.GetComponent<KingNav>().health -= 50;
                GameObject assassinExplosionInst = Instantiate(assassinExplosion);
                assassinExplosionInst.transform.position = this.transform.position;
                Destroy(this.gameObject);
            }
        }
        else
        {
            if ((transform.position.x == goal.x && transform.position.z == goal.z) || (Time.time > (timeOfLastDirectionChange + directionChangeInterval)))
            {
                //pick new random destination
                Vector3 direction = Random.insideUnitSphere * max_walk_distance;
                direction += transform.position;
                UnityEngine.AI.NavMeshHit hit;
                UnityEngine.AI.NavMesh.SamplePosition(direction, out hit, Random.Range(1f, max_walk_distance), 1);
                timeOfLastDirectionChange = Time.time;
                goal = hit.position;
                navi.SetDestination(goal);
            }
        }
    }

    void FixedUpdate()
    {
        //RANDOMLY BECOME ASSASSIN?
        if (Random.Range(0, chanceToBecomeAssassinOneIn) < 1)
        {
            Assassin = true;
            goal = king.transform.position;
            navi.speed = assassinSpeed;
            directionChangeInterval = 2f;
            characterMesh.GetComponent<Renderer>().material = assassinMat;
            navi.SetDestination(goal);
        }
    }
}
