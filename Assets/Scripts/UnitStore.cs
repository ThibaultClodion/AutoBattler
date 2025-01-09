using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitStore : MonoBehaviour
{
    [Header("Units")]
    [SerializeField] private Character[] payableUnits;
    private Character selectedUnit;
    [SerializeField] private Button unitButtonPrefab;

    [Header("Unit Placement")]
    [SerializeField] private GameObject unitVisualization;
    [SerializeField] private LayerMask unitPlacableLayerMask;

    [Header("Money")]
    [SerializeField] private TextMeshProUGUI moneyText;
    private float money;

    void Start()
    {
        selectedUnit = payableUnits[0];    // Ensure that one unit is selected
        CreateUnitButtons();

        AddToMoney(500); //Todo : make a level scriptable object that give a money amount
    }

    private void OnEnable()
    {
        if (unitVisualization != null)
        {
            unitVisualization.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if(unitVisualization != null)
        {
            unitVisualization.SetActive(false);
        }
    }

    private void Update()
    {
        MoveUnitVisualisationToMouse();

        //Prevent unit creation if player click on UI
        if (Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject()
            && money >= selectedUnit.GetPrice())
        {
            AddToMoney(-selectedUnit.GetPrice());
            GameManager.InstantiateAlly(selectedUnit, unitVisualization.transform.position, GameManager.kings[0] == null);
        }
    }

    private void MoveUnitVisualisationToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, unitPlacableLayerMask))
        {
            unitVisualization.transform.position = hit.point;
        }
    }

    private void CreateUnitButtons()
    {
        foreach (Character character in payableUnits)
        {
            Button unitButton = Instantiate(unitButtonPrefab, transform);
            unitButton.onClick.AddListener(delegate { ChangeSelectedUnit(character); } );
        }
    }

    private void ChangeSelectedUnit(Character character)
    {
        selectedUnit = character;
    }

    private void AddToMoney(int amount)
    {
        money += amount;
        moneyText.text = "Money : " + money;
    }
}