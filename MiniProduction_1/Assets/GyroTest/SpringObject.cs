using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpringObject : MonoBehaviour, IPointerClickHandler,IDragHandler, IBeginDragHandler,IEndDragHandler {
    public Vector3 startPosition;
	public Vector3 currentPosition;
	[SerializeField]
	GameObject player;
	[SerializeField]
	GameObject enemy;

	GameObject enemyClone;
	GameObject playerClone;	

	Vector3 playerStartPosition;
	Vector3 enemyStartPosition;
	Quaternion enemyStartRotation;
	Quaternion playerStartRotation;
	Rigidbody rigidbody;

	RectTransform rectTransform;

	[Range(0,100)]
	public float drag = 20;
	[Range(0,10000)]
	public float force = 4000;
	[Range(0,100)]
	public float mass = 80;
	public ForceMode forceMode;

	public void ResetEverything()
	{
		enemy.transform.position = enemyStartPosition;
		player.transform.position = playerStartPosition;
		rigidbody.velocity = Vector3.zero;
		enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
		Destroy(player);
		Destroy(enemy);
		enemy = Instantiate(enemyClone,enemyStartPosition,enemyStartRotation);
		player = Instantiate(playerClone,playerStartPosition,playerStartRotation);
		rigidbody = player.GetComponent<Rigidbody>();
		enemy.SetActive(true);
		player.SetActive(true);
	}

	void SettingPublicVariables()
	{
		rigidbody.drag = drag;
		rigidbody.mass = mass;
	}
	public void OnBeginDrag(PointerEventData eventData)
    {
		player.GetComponent<MovePlayerBack>().Stop();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ThrowPlayer();
		ResetDragObjectPosition();
    }

	void ThrowPlayer()
	{
		//Vector3 currentPosition = transform.position;
		//Vector3 currentPosition = rectTransform.position;
		Vector3 angle = Vector3.Normalize(startPosition - currentPosition);
		angle.z = 0;
		float distance = Vector3.Distance(startPosition,currentPosition) / 100;
		Vector3 forceToAt = angle *(distance) * force; 
		Debug.Log(forceToAt);
		rigidbody.AddForce(forceToAt,forceMode);
		player.GetComponent<MovePlayerBack>().MoveBack();
		enemy.GetComponent<MovePlayerBack>().MoveBack();

	}
	void ResetDragObjectPosition()
	{
		transform.position = startPosition;
	}
    // Use this for initialization
    void Start () {
		rectTransform = GetComponent<RectTransform>();
		startPosition = transform.position;
		//startPosition = Camera.main.ScreenToWorldPoint( rectTransform.position);
		rigidbody = player.GetComponent<Rigidbody>();
		SetupResetVariables();
	}
	void SetupResetVariables()
	{
		enemyStartPosition = enemy.transform.position;
		enemyStartRotation = enemy.transform.rotation;
		playerStartPosition = player.transform.position;
		playerStartRotation = player.transform.rotation;
		enemyClone = Instantiate(enemy,enemyStartPosition,enemy.transform.rotation);
		playerClone = Instantiate(player,playerStartPosition,player.transform.rotation);
		enemyClone.SetActive(false);
		playerClone.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		//currentPosition = Camera.main.WorldToScreenPoint(rectTransform.position);
		currentPosition = rectTransform.position;
		SettingPublicVariables();
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicking");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = Camera.main.ScreenToViewportPoint(eventData.position);
		transform.position = eventData.position;
		Debug.Log(eventData.position);
    }
}
