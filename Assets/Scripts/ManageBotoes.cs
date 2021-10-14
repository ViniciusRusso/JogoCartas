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
     * Fun��o para que o bot�o "START" leve � cena do jogo da mem�ria
     */
    public void StartGame()
    {
        SceneManager.LoadScene("JogoMemoria");
    }

    /* AbrirMenu
     * Fun��o para que o bot�o "Voltar ao Menu" leve � cena do menu principal do jogo
     */
    public void AbrirMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /* FecharJogo
     * Fun��o para que o bot�o "Fechar Jogo" feche a aplica��o
     */
    public void FecharJogo()
    {
        Application.Quit();
    }

    /* VerCreditos
     * Fun��o para que o bot�o "Cr�ditos" leve � cena dos cr�ditos do jogo
     */
    public void VerCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    /* AcessarConfiguracoes
     * Função para acessar o menu de opções
     */
    public void MenuConfiguracoes()
    {
        SceneManager.LoadScene("Configuracoes");
    }

    public void SomenteVermelhas(){
        ManageCartas.gameMode = 2;
    }

    public void SomentePretas(){
        ManageCartas.gameMode = 1;
    }

    public void FundosDiferentes(){
        ManageCartas.gameMode = 3;
    }

    public void TodasAsCartas(){
        ManageCartas.gameMode = 4;
    }
}
