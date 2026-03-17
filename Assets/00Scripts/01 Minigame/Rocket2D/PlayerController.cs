using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speedMove = 1f;
    [SerializeField] private GameObject booterFlame;
    [SerializeField] private GameObject explosionEffect;
    private Button restartButton;
    private Label scoreTxt;
    [SerializeField] private UIDocument uiDocument;
    private float timeScore =0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        scoreTxt = uiDocument.rootVisualElement.Q<Label>("TextScore");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;

    }

    // Update is called once per frame
    void Update()
    {
        timeScore += Time.deltaTime;
        int timeInt = Mathf.FloorToInt(timeScore);
        scoreTxt.text = "Score: "+timeInt.ToString();
        booterFlame.SetActive(false);
          Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        Vector2 direction = mousePos - this.transform.position;
        transform.up = direction;
        if (Mouse.current.leftButton.isPressed)
        {
            rb.AddForce(direction.normalized * speedMove);
            booterFlame.SetActive(true);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false);
        Instantiate(explosionEffect,this.transform.position,Quaternion.identity);
        restartButton.style.display = DisplayStyle.Flex;
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
