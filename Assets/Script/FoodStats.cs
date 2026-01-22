using UnityEngine;
[System.Serializable]
public class FoodStats 
{
    [Range(-10f, 10f)]
    public float Salado = 0;
    [Range(-10f, 10f)]
    public float Dulce = 0;
    [Range(-10f, 10f)]
    public float Picante=0;
    [Range(-10f, 10f)]
    public float Horneado=0;


    public FoodStats(bool randomize)
    {
        if (!randomize) return;
        Salado = Random.Range(0f, 10f);
        Dulce = Random.Range(0f, 10f);
        Picante = Random.Range(0f, 10f);
        Horneado = Random.Range(0f, 10f);
    }

    public void AddStats(FoodStats _food)
    {
        if (_food == null) return;

        this.Salado += _food.Salado;
        this.Dulce += _food.Dulce;
        this.Picante += _food.Picante;
        this.Horneado += _food.Horneado;


    }




}
public enum FoodStatType
{
    Salado,
    Dulce,
    Picante,
    Horneado
}
