using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Classe ManageRecorde
 * Gerencia o recorde do jogador e os textos na cena de vitória
 */
public class ManageRecorde : MonoBehaviour
{
    public Text recordeAtual;   // guarda o recorde do jogador
    AudioSource aplausos;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("scoreAtual").GetComponent<Text>().text = "Tentativas na última rodada: " + PlayerPrefs.GetInt("Jogadas", 0).ToString();
        UpdateRecorde();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateRecorde()
    {
        if (PlayerPrefs.GetInt("Jogadas", 0) < PlayerPrefs.GetInt("HighScore", 0) || PlayerPrefs.GetInt("HighScore", 0) == 0)
        {
            recordeAtual.text = "NOVO RECORDE: " + PlayerPrefs.GetInt("Jogadas", 0).ToString();
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Jogadas", 0));
            //tocar som de novo recorde
            aplausos = GetComponent<AudioSource>();
            aplausos.Play();
        }
        else
            recordeAtual.text = "Recorde: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
