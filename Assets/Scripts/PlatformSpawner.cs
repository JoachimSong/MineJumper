using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float scale;
    public List<GameObject> platforms;
    public IntEventSO scoreUpEvent;
    // Start is called before the first frame update
    private void OnEnable()
    {
        scoreUpEvent.OnEventRaised += UpdatePlatform;
    }
    private void OnDisable()
    {
        scoreUpEvent.OnEventRaised -= UpdatePlatform;
    }
    private void UpdatePlatform(int num)
    {
        destroyPlatforms();
        generatePlatform();
    }
    void Start()
    {
        generatePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generatePlatform()
    {
        float randomX = Random.Range(transform.position.x - scale / 2, transform.position.x + scale / 2);
        float randomZ = Random.Range(transform.position.z - scale / 2, transform.position.z + scale / 2);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, randomZ);
        int index = Random.Range(0, platforms.Count);
        GameObject newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);
        newPlatform.transform.SetParent(this.gameObject.transform);
    }

    public void destroyPlatforms()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
