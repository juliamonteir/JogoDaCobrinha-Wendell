using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CarregarCena : MonoBehaviour
{
    public string cenaparaCarregar;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(cenaparaCarregar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
