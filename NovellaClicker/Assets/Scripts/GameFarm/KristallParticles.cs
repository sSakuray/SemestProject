using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class KristallParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem part;
    public void Particles()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(CreatePart());
        }
    }

    IEnumerator CreatePart()
    {
        part.Play();
        yield return new WaitForSeconds(0.1f);
        part.Stop();
    }
}
