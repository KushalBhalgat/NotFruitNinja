using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{

    public GameObject[] fruits;
    public GameObject bombPrefab;

    [Range (0f,1f)]
    private float bombProbability=DifficultyPorter.instance.bombProbability;
    private Collider spawnArea;

    public float minDelay=DifficultyPorter.instance.bounds[0];
    public float maxDelay=DifficultyPorter.instance.bounds[1];
    public float minForce=18f;
    public float maxForce=22f;
    public float lifeTime=5f;

    public float minAngle=-15f;
    public float maxAngle=+15f;


    private void Awake() {
        spawnArea=GetComponent<Collider>();

    }

    private IEnumerator Spawn(){
        yield return new WaitForSeconds(2f);
        
        while(enabled){
            GameObject prefab=fruits[Random.Range(0,5)];

            if(Random.value<bombProbability){
                prefab=bombPrefab;
            }
            Vector3 position;
            position.x=Random.Range(spawnArea.bounds.min.x,spawnArea.bounds.max.x);
            position.y=Random.Range(spawnArea.bounds.min.y,spawnArea.bounds.max.y);
            position.z=Random.Range(spawnArea.bounds.min.z,spawnArea.bounds.max.z);

            Quaternion rotation= Quaternion.Euler(0f,0f, Random.Range(minAngle,maxAngle));  
            GameObject platform= GameObject.FindWithTag("Spawner");
            GameObject fruit = Instantiate(prefab,position,rotation); 
            Destroy(fruit,lifeTime);

            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up*Random.Range(minForce,maxForce),ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
        }
    }

    private void OnEnable() {
        StartCoroutine(Spawn());
    }

    private void OnDisable() {
        StopAllCoroutines();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate() {
        
    }
}
