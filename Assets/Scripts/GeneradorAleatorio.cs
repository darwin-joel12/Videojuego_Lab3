using UnityEngine;

public class GeneradorAleatorio : MonoBehaviour
{
    public GameObject[] prefabsObstaculos;
    public float tiempoAparicion = 1.5f;
    public float velocidadMovimiento = 5f;

    void Start()
    {
        InvokeRepeating("Crear", 1f, tiempoAparicion);
    }

    void Crear()
    {
        int indice = Random.Range(0, prefabsObstaculos.Length);
        GameObject obj = prefabsObstaculos[indice];

        // Simplificamos: ¿Es meteorito? (True/False)
        bool esMeteorito = obj.name.ToLower().Contains("meteorito");

        // POSICIÓN: Si es meteorito sale de arriba (X aleatoria), si no, de la derecha (Y fija)
        Vector3 pos = esMeteorito ?
            new Vector3(Random.Range(-5f, 12f), 7f, 0) :
            new Vector3(12f, Random.Range(0, 2) == 0 ? -4.5f : 4.5f, 0);

        // DIRECCIÓN: Si es meteorito va en diagonal (-1,-1), si no, recto a la izquierda (-1,0)
        Vector3 dir = esMeteorito ? new Vector3(-1, -1, 0).normalized : Vector3.left;

        // INSTANCIAR Y MOVER
        GameObject nuevo = Instantiate(obj, pos, Quaternion.identity);
        nuevo.AddComponent<MoverObjeto>().Configurar(velocidadMovimiento, dir);
    }
}

public class MoverObjeto : MonoBehaviour
{
    private float vel;
    private Vector3 dir;

    public void Configurar(float v, Vector3 d) { vel = v; dir = d; }

    void Update()
    {
        transform.Translate(dir * vel * Time.deltaTime);
        if (transform.position.x < -15 || transform.position.y < -10) Destroy(gameObject);
    }
}