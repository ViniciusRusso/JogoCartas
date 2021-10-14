using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool tileRevelada = false;          // indica se a carta est� virada ou n�o
    public Sprite originalCarta;                // sprite da face frontal a carta
    public Sprite backCarta;                    // sprite da face traseira da carta
    public Sprite backCartaAlt;                 // Sprite da face traseira alternativa (outra cor)

    // Start is called before the first frame update
    void Start()
    {
        /*if(ManageCartas.gameMode == 3){
            EscondeCarta(1);
        }
        else{
            EscondeCarta(0);
        }*/
        EscondeCarta();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        print("Voc� pressionou um tile.");
        GameObject.Find("gameManager").GetComponent<ManageCartas>().CartaSelecionada(gameObject);
    }

    /*public void EscondeCarta(int linha)
    {
        if((ManageCartas.gameMode == 3) && (linha == 1)){
            GetComponent<SpriteRenderer>().sprite = backCartaAlt;
        }
        else{
            GetComponent<SpriteRenderer>().sprite = backCarta;
        }
        tileRevelada = false;
    }*/

    public void EscondeCarta()
    {
        GetComponent<SpriteRenderer>().sprite = backCarta;
        tileRevelada = false;
    }

    public void RevelaCarta()
    {
        GetComponent<SpriteRenderer>().sprite = originalCarta;
        tileRevelada = true;
    }

    public void SetCartaOriginal(Sprite novaCarta)
    {
        originalCarta = novaCarta;
    }

    public void SetCartaTraseira(Sprite novaTraseira)
    {
        backCarta = novaTraseira;
    }
}
