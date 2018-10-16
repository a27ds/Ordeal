using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPortController : MonoBehaviour {

    public ParticleSystem ghostPortParticle;
    public GameObject ghostPrefab;
    public OptionsController optionsController;

    float timeInLight;
    bool spawnGhost = true;

    public List<Color> LifeCycleColors = new List<Color>();

    private void OnEnable()
    {
        LifeViewController.Dead += LifeViewController_Dead;
    }

    private void OnDisable()
    {
        LifeViewController.Dead -= LifeViewController_Dead;
    }

    void LifeViewController_Dead()
    {
        Destroy(gameObject);
    }

    void Start () 
    {
        StartCoroutine(SpawnGhost());
	}

    private void Update()
    {
        PortLifeCycle();
    }

    void PortLifeCycle()
    {
        var main = ghostPortParticle.main;
        if (timeInLight < optionsController.ghostPortLifeInSeconds) {
            int index = (int) (timeInLight * LifeCycleColors.Count / optionsController.ghostPortLifeInSeconds);
            main.startColor = LifeCycleColors[index];
        }
        else 
        {
            ghostPortParticle.Stop(true);
            if (ghostPortParticle.particleCount <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator SpawnGhost()
    {
        var ghostFolder = new GameObject();
        ghostFolder.name = "Ghosts";
        while (spawnGhost)
        {
            if (ghostPortParticle.particleCount >= 150)
            {
                GameObject newGhost = Instantiate(ghostPrefab, transform.position + ((Vector3)Random.insideUnitCircle * 0.3f), Quaternion.identity);
                newGhost.transform.SetParent(ghostFolder.transform);
            }
            yield return new WaitForSecondsRealtime(optionsController.spawnDelay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Light(Clone)"))
        {
            timeInLight += Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Light(Clone)"))
        {
            timeInLight += Time.deltaTime;
        }
    }
}
