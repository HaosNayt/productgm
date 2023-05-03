using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
