using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitStore : MonoBehaviour
{
    [Header("Units")]
    [SerializeField] private Character[] payableUnits;
    private Character selectedUnit;
    [SerializeField] private UnitButton unitButtonPrefab;

    [Header("Unit Placement")]
    [SerializeField] private GameObject unitVisualization;
    [SerializeField] private LayerMask unitPlacableLayerMask;

    [Header("Money")]
    [SerializeField] private int startingMoney;
    [SerializeField] private TextMeshProUGUI moneyText;
    private int money;

    void Start()
    {
        selectedUnit = payableUnits[0];    // Ensure that one unit is selected
        CreateUnitButtons();

        AddToMoney(startingMoney);
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
            GameManager.Instance.InstantiateAlly(selectedUnit, unitVisualization.transform.position, GameManager.Instance.kings[0] == null);
        }
    }

    private void MoveUnitVisualisationToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, unitPlacableLayerMask))
        {
            unitVisualization.transform.position = hit.point + new Vector3(0, 0.1f, 0);
        }
    }

    private void CreateUnitButtons()
    {
        foreach (Character character in payableUnits)
        {
            UnitButton unitButton = Instantiate(unitButtonPrefab, transform);
            unitButton.button.onClick.AddListener(delegate { ChangeSelectedUnit(character); } );
            unitButton.Init(character.GetSprite());
        }
    }

    private void ChangeSelectedUnit(Character character)
    {
        selectedUnit = character;
    }

    private void AddToMoney(int amount)
    {
        money += amount;
        moneyText.text = money.ToString();
    }
}