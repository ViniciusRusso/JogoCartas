using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageBotoes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* StartGame
     * Função para que o botão "START" leve à cena do jogo da memória
     */
    public void StartGame()
    {
        SceneManager.LoadScene("JogoMemoria");
    }

    /* AbrirMenu
     * Função para que o botão "Voltar ao Menu" leve à cena do menu principal do jogo
     */
    public void AbrirMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /* FecharJogo
     * Função para que o botão "Fechar Jogo" feche a aplicação
     */
    public void FecharJogo()
    {
        Application.Quit();
    }

    /* VerCreditos
     * Função para que o botão "Créditos" leve à cena dos créditos do jogo
     */
    public void VerCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
