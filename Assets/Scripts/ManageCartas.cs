using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageCartas : MonoBehaviour
{
    public GameObject carta;                    // A carta a ser descartada
    private bool primeiraCartaSelecionada, segundaCartaSelecionada;     // indicadores para cada carta escolhida em cada linha
    private GameObject carta1, carta2;          // gameObjects da 1� e 2� carta selecionadas
    private string linhaCarta1, linhaCarta2;    // linha da carta selecionada
    public static int gameMode = 0;             // Define o Modo de Jogo
    public static int guardaLinha = 0;              // Guarda a linha para ser usada em outra tela

    bool timerPausado, timerAcionado;   // indicador de pausa no timer ou start timer
    float timer;                        // vari�vel de tempo

    int numTentativas = 0;      // n�mero de tentativas na rodada
    int numAcertos = 0;         // n�mero de pares acertados
    AudioSource somAcerto;      // som de acerto

    int ultimoJogo = 0;

    // Start is called before the first frame update
    void Start()
    {
        MostraCartas();
        UpdateTentativas();
        somAcerto = GetComponent<AudioSource>();
        ultimoJogo = PlayerPrefs.GetInt("Jogadas", 0);
        GameObject.Find("ultimaJogada").GetComponent<Text>().text = "Jogo anterior: " + ultimoJogo;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerAcionado)
        {
            timer += Time.deltaTime;
            print(timer);
            if (timer > 1)
            {
                timerPausado = true;
                timerAcionado = false;
                if (carta1.tag == carta2.tag)
                {
                    Destroy(carta1);
                    Destroy(carta2);
                    numAcertos++;
                    somAcerto.Play();
                    if (numAcertos == 13)
                    {
                        PlayerPrefs.SetInt("Jogadas", numTentativas);
                        SceneManager.LoadScene("Vitoria");
                    }
                }
                else
                {
                    carta1.GetComponent<Tile>().EscondeCarta();
                    carta2.GetComponent<Tile>().EscondeCarta();
                }
                primeiraCartaSelecionada = false;
                segundaCartaSelecionada = false;
                carta1 = null;
                carta2 = null;
                linhaCarta1 = "";
                linhaCarta2 = "";
                timer = 0;
            }
        }
    }

    /* MostraCartas
     * Chama outras fubções para criar arrays com as 13 cartas de um naipe e
     * para criar as cartas baseadas no prefab tile
     */
    void MostraCartas()
    {
        int[] arrayEmbaralhado = CriaArrayEmbaralhado();
        int[] arrayEmbaralhado2 = CriaArrayEmbaralhado();
        int[] arrayEmbaralhado3 = CriaArrayEmbaralhado();
        int[] arrayEmbaralhado4 = CriaArrayEmbaralhado();       

        if(gameMode == 4){
            for (int i = 0; i < 13; i++)
            {
                AddUmaCarta(0, i, arrayEmbaralhado[i]);
                AddUmaCarta(1, i, arrayEmbaralhado2[i]);
                AddUmaCarta(2, i, arrayEmbaralhado3[i]);
                AddUmaCarta(3, i, arrayEmbaralhado4[i]);
            }
        }

        /*else if(gameMode == 3){
            for (int i = 0; i < 13; i++)
            {
                AddUmaCarta(0, i, arrayEmbaralhado[i]);
                AddUmaCarta(1, i, arrayEmbaralhado2[i]);
            }
            carta.GetComponent<Tile>().EscondeCarta(0);
            carta.GetComponent<Tile>().EscondeCarta(1);
        }*/

        else{

            for (int i = 0; i < 13; i++)
            {
                AddUmaCarta(0, i, arrayEmbaralhado[i]);
                AddUmaCarta(1, i, arrayEmbaralhado2[i]);
            }
        }
    }

    /* AddUmaCarta
     * Função que cria as cartas, adicionando seu naipe e valor, com
     * base no prefab tile e no modo de jogo escolhido
     */
    void AddUmaCarta(int linha, int rank, int valor)
    {
        GameObject centro = GameObject.Find("centroDaTela");
        float escalaCartaOriginal = carta.transform.localScale.x;
        float fatorEscalaX = (650 * escalaCartaOriginal) / 110.0f;
        float fatorEscalaY = (945 * escalaCartaOriginal) / 110.0f;
        Vector3 novaPosicao = new Vector3(centro.transform.position.x + ((rank - 13 / 2) * fatorEscalaX), centro.transform.position.y + ((linha - 2 / 2) * fatorEscalaY), centro.transform.position.z);
        GameObject c = (GameObject)Instantiate(carta, novaPosicao, Quaternion.identity);
        c.tag = "" + (valor + 1);
        c.name = "" + linha + "_" + valor;
        string nomeDaCarta = "";
        string numeroCarta = "";
        if (valor == 0)
            numeroCarta = "ace";
        else if (valor == 10)
            numeroCarta = "jack";
        else if (valor == 11)
            numeroCarta = "queen";
        else if (valor == 12)
            numeroCarta = "king";
        else
            numeroCarta = "" + (valor + 1);
        guardaLinha = linha;
        // if linha == 0 _of_hearts else _of_clubs
        //nomeDaCarta = numeroCarta + "_of_clubs";
        if(gameMode == 0){
            nomeDaCarta = numeroCarta + "_of_clubs";
        }
        else if((gameMode == 1) && linha == 0){
            nomeDaCarta = numeroCarta + "_of_clubs";
        }
        else if((gameMode == 1) && linha == 1){
            nomeDaCarta = numeroCarta + "_of_spades";
        }
        if((gameMode == 2) && linha == 0){
            nomeDaCarta = numeroCarta + "_of_diamonds";
        }
        else if((gameMode == 2) && linha == 1){
            nomeDaCarta = numeroCarta + "_of_hearts";
        }
        if((gameMode == 3) && linha == 0){
            nomeDaCarta = numeroCarta + "_of_clubs";
        }
        else if((gameMode == 3) && linha == 1){
            nomeDaCarta = numeroCarta + "_of_clubs";
        }
        if((gameMode == 4) && linha == 0){
            nomeDaCarta = numeroCarta + "_of_diamonds";
        }
        if((gameMode == 4) && linha == 1){
            nomeDaCarta = numeroCarta + "_of_clubs";
        }
        else if((gameMode == 4) && linha == 2){
            nomeDaCarta = numeroCarta + "_of_hearts";
        }
        else if((gameMode == 4) && linha == 3){
            nomeDaCarta = numeroCarta + "_of_spades";
        }
        
        Sprite s1 = (Sprite)(Resources.Load<Sprite>(nomeDaCarta));
        print("S1 " + s1);
        Sprite s2 = (Sprite)(Resources.Load<Sprite>("playCardBackBlue")); 
        if((linha == 1) && (gameMode == 3)){

            GameObject.Find("" + linha + "_" + valor).GetComponent<Tile>().SetCartaTraseira(s2);    
        }
        GameObject.Find("" + linha + "_" + valor).GetComponent<Tile>().SetCartaOriginal(s1);
    }

    /* CriaArrayEmbaralhado
     * Função que embaralha a ordem dos valores das 13 cartas de um naipe
     */
    public int[] CriaArrayEmbaralhado()
    {
        int[] novoArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        int temp;
        for (int t = 0; t < 13; t++)
        {
            temp = novoArray[t];
            int r = Random.Range(t, 13);
            novoArray[t] = novoArray[r];
            novoArray[r] = temp;
        }
        return novoArray;
    }

    /* CartaSelecionada
     * Função que verifica quantas cartas foram selecionadas e,
     * após a segunda carta selecionada chama VerificaCartas
     */
    public void CartaSelecionada(GameObject carta)
    {
        if (!primeiraCartaSelecionada)
        {
            string linha = carta.name.Substring(0, 1);
            linhaCarta1 = linha;
            primeiraCartaSelecionada = true;
            carta1 = carta;
            carta1.GetComponent<Tile>().RevelaCarta();
        }
        else if (primeiraCartaSelecionada && !segundaCartaSelecionada)
        {
            string linha = carta.name.Substring(0, 1);
            linhaCarta2 = linha;
            segundaCartaSelecionada = true;
            carta2 = carta;
            carta2.GetComponent<Tile>().RevelaCarta();
            VerificaCartas();
        }
    }

    /* VerificaCartas
     * Função que chama DisparaTimer para esconder as cartas,
     * aumenta o número de tentativas de formar os pares
     * e chama UpdateTentativas
     */
    public void VerificaCartas()
    {
        DisparaTimer();
        numTentativas++;
        UpdateTentativas();
    }

    /* DisparaTimer
     * Função que altera as variáveis booleanas que controlam
     * quando o timer estará ativo
     */
    public void DisparaTimer()
    {
        timerPausado = false;
        timerAcionado = true;
    }

    /* UpdateTentativas
     * Função que altera o texto de número de tentativas na tela do jogo
     */
    void UpdateTentativas()
    {
        GameObject.Find("numTentativas").GetComponent<Text>().text = "Tentativas: " + numTentativas;
    }
}
