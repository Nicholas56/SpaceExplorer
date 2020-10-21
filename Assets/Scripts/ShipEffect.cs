using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEffect : MonoBehaviour
{
    public ParticleSystem deathEffect;
    public MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayDeath()
    {
        deathEffect.Play();
        DisableShip();
        if(gameObject.tag=="Player")
        GameObject.Find("OptionsManager").GetComponent<ScoreManager>().gs = ScoreManager.gameState.enterscore;
    }

    void DisableShip()
    {
        mesh.enabled = false;
        CheckChildren(gameObject);
    }

    void CheckChildren(GameObject objectToCheck)
    {
        if (objectToCheck.transform.childCount > 0)
        {
            for (int i = 0; i < objectToCheck.transform.childCount; i++)
            {
                if (objectToCheck.transform.GetChild(i).TryGetComponent(out Light light))
                {
                    light.enabled = false;
                }
                if (objectToCheck.transform.GetChild(i).TryGetComponent(out ParticleSystem particle))
                {
                    if (transform.name != "DeathEffect")
                    {
                        particle.Stop();
                    }
                }
                CheckChildren(objectToCheck.transform.GetChild(i).gameObject);
            }
        }
    }
}
