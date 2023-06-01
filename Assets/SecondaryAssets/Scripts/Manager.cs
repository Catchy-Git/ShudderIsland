using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private Vector3 PlayerTransform;
    public GameObject mainCamera;
    public GameObject player;
    public Slider playerSlider;
    public Vector3 CurrentPosition;
    public Vector3 LastHeroPosition;

    public GameObject hooded;
    public GameObject hunter;
    public GameObject hammer;
    public GameObject sharpshooter;

    int player_Number = 0;

    public AudioSource PickUpNoise;

    public EnemyPatrolScript enemyPatrol;
    private Vector3 TeleportGoal;
    public GameObject TeleportGoalEnemy;
    public bool ZombieAlive = false;
    public bool MonsterAlive = false;
    public bool GhoulAlive = false;
   
   
    public int abilityCounter;
    private GameObject enemytype;
    private Movement movement;
    public GameObject battleHud;
    public GameObject newEnemy;
    
    public int playerDMG;
    public int abilityDMG;

    private int enemyHp;
    private int enemyCurrentHp;
    public int PlayerHp;
    public int PlayerCurrentHp;

    public int enemyDMG = 5;

    public Button AbilityButton;
    public Button AttackButton;
    
    
   
    public enum BattleStates
    {
        Start,
        PlayerTurn,
        EnemyTurn,
        Won,
        Lost
    }


    public enum GameStates
    {
        World_State,
        Battle_State,
        Idle,
        Menu_State

    }

    public GameStates gameStates;
    public BattleStates battleStates;

    void Awake()
    {  
       
       

        player_Number = PlayerPrefs.GetInt("Player");
        PlayerHp = PlayerPrefs.GetInt("Player_Health");
        Debug.Log(player);

        if (player_Number == 1)
        {
            playerDMG = 5;
            abilityDMG = 40;
            abilityCounter = 3;
            playerSlider.value = PlayerHp;
            hunter.SetActive(true);
        }

        if (player_Number == 2)
        {
            playerDMG = 5;
            abilityDMG = 40;
            abilityCounter = 3;
            playerSlider.value = PlayerHp;
            hooded.SetActive(true);

        }
        if (player_Number == 3)
        {
            playerDMG = 5;
            abilityDMG = 40;
            abilityCounter = 3;
            playerSlider.value = PlayerHp;
            hammer.SetActive(true);
        }

        if (player_Number == 4)
        {
            playerDMG = 5;
            abilityDMG = 40;
            abilityCounter = 3;
            playerSlider.value = PlayerHp;
            sharpshooter.SetActive(true);
        }
    }

    void Start()
    {
       
            PlayerCurrentHp = PlayerHp;
        player = GameObject.FindGameObjectWithTag("Player");
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        battleHud.SetActive(false);
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
        TeleportGoal = GameObject.Find("PlayerBattleSpawn").gameObject.transform.position;
       
    }

    void Update()
    {
        CurrentPosition = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
        //Debug.Log("Current " + CurrentPosition);
        //Debug.Log("Last hero position " + LastHeroPosition);
        switch (gameStates)
        {
           
            case (GameStates.World_State):
                if(movement.Attacked == true)
                {
                    //Debug.Log("Before EnemyType");
                    EnemyType();
                    //LastHeroPosition = GameObject.Find("Hooded").gameObject.transform.position;
                    //Debug.Log("Before");
                    newEnemy = Instantiate(enemytype, TeleportGoalEnemy.transform.position, TeleportGoalEnemy.transform.rotation);

                    //Debug.Log("After");
                    
                    gameStates = GameStates.Battle_State;
                    //Debug.Log("After Game");
                    
                }

                break;

            case (GameStates.Battle_State):
                battleStates = BattleStates.Start;

                StartBattle();
                //gameStates = GameStates.Idle;
                break;

            case (GameStates.Idle):
                //enemyPatrol.chase = false;
                break;
        }
        Debug.Log(gameStates);
    }

    void StartBattle()
    {

        // PlayerTransform =  GameObject.Find("HeroBattleStation").gameObject.transform.position;


        //Instantiat Enemy on the enemy spawnblock.
        
        battleHud.SetActive(true);
        movement.isWalking = false;
        enemyPatrol.chase = false;
        player.GetComponent<Animator>().SetBool("isMoving", false);
        player.GetComponent<Animator>().SetBool("isRunning", false);
        player.GetComponent<Animator>().SetBool("RightTurn", false);
        player.GetComponent<Animator>().SetBool("LeftTurn", false);
        player.GetComponent<Animator>().SetBool("isMovingBack", false);
        battleStates = BattleStates.PlayerTurn;

        PlayerTurn();


        
        //////////////////////////////////////////////////////////////////////////////////////////////
    }

    void EndBattle()
    {
        battleHud.SetActive(false);
        movement.isWalking = true;
        
        movement.Attacked = false;
        Destroy(newEnemy, 1.0f);
        ZombieAlive = false;
        MonsterAlive = false;
        GhoulAlive = false;

    }


    void EnemyType()
    {
        if(ZombieAlive)
        {
            enemyDMG = 35;
            enemyHp = 10;
            enemyCurrentHp = enemyHp;
            enemytype = GameObject.FindGameObjectWithTag("Zombie");
            Debug.Log("Zombie");
        }
        if (MonsterAlive)
        {
            
            enemyDMG = 40;
            enemyHp = 10;
            enemyCurrentHp = enemyHp;
            enemytype = GameObject.FindGameObjectWithTag("Monster");
            Debug.Log("Monster");
        }
        if (GhoulAlive)
        {
            
            enemyDMG = 50;
            enemyHp = 10;
            enemyCurrentHp = enemyHp;
            enemytype = GameObject.FindGameObjectWithTag("Ghoul");
            Debug.Log("Ghoul");
        }
    }

    
    public void PlayupSound()
    {
        PickUpNoise.Play();
    }
    

    IEnumerator PlayerAttack()
    {
        AttackButton.interactable = false;
        Debug.Log("Attack Button");
        //Damage the enemy
        player.GetComponent<Animator>().SetBool("isAttacking", true);
        
        yield return new WaitForSeconds(4f);
        
       
        Debug.Log("Enemy DMG " + enemyDMG);
        Debug.Log("Enemy Current Hp" + enemyCurrentHp);
        enemyCurrentHp -= playerDMG;

        Debug.Log("Enemy DMG " + enemyDMG);
        Debug.Log("Enemy Current Hp" + enemyCurrentHp);

        if (enemyCurrentHp <= 0)
        {
            Debug.Log("You win");
            newEnemy.GetComponent<Animator>().SetBool("isDead", true);
            battleHud.SetActive(false);
            yield return new WaitForSeconds(3f);
            EndBattle();
            gameStates = GameStates.World_State;
            //End Battle
            mainCamera.transform.position = enemyPatrol.LastCameraPosition.transform.position;
            mainCamera.transform.rotation = enemyPatrol.LastCameraPosition.transform.rotation;
            player.transform.position = LastHeroPosition;
            //PlayerTransform = LastHeroPosition;
        }
        else
        {
            battleStates = BattleStates.EnemyTurn;

            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy Attack");
        newEnemy.GetComponent<Animator>().SetBool("isAttacking", true);
       
        yield return new WaitForSeconds(4f);
        
      
            Debug.Log("PlayerCurrentHP " + PlayerCurrentHp);
            Debug.Log("Enemy DMG " + enemyDMG);
            PlayerCurrentHp -= enemyDMG;
        playerSlider.value = PlayerCurrentHp;
        Debug.Log("PlayerCurrentHP " + PlayerCurrentHp);
            Debug.Log("Enemy DMG " + enemyDMG);
        
        if (PlayerCurrentHp <= 0)
        {
            battleHud.SetActive(false);
            Debug.Log("You Lose, Game Over");
            player.GetComponent<Animator>().SetBool("isDead", true);
            yield return new WaitForSeconds(3f);
            //Game Over
        }
        else
        {
            battleStates = BattleStates.PlayerTurn;
            Debug.Log("Player Turn");
            PlayerTurn();

        }
    }

    IEnumerator AbilityAttack()
    {
        AbilityButton.interactable = false;
        Debug.Log("Attack Button");
        //Damage the enemy
        player.GetComponent<Animator>().SetBool("isAbility", true);

        yield return new WaitForSeconds(4f);


        Debug.Log("Enemy DMG " + enemyDMG);
        Debug.Log("Enemy Current Hp" + enemyCurrentHp);
        enemyCurrentHp -= abilityDMG;

        Debug.Log("Enemy DMG " + enemyDMG);
        Debug.Log("Enemy Current Hp" + enemyCurrentHp);

        if (enemyCurrentHp <= 0)
        {
            Debug.Log("You win");
            newEnemy.GetComponent<Animator>().SetBool("isDead", true);
            battleHud.SetActive(false);
            yield return new WaitForSeconds(3f);
            EndBattle();
            gameStates = GameStates.World_State;
            //End Battle
            mainCamera.transform.position = enemyPatrol.LastCameraPosition.transform.position;
            mainCamera.transform.rotation = enemyPatrol.LastCameraPosition.transform.rotation;
            player.transform.position = LastHeroPosition;
            //PlayerTransform = LastHeroPosition;
        }
        else
        {
            battleStates = BattleStates.EnemyTurn;

            StartCoroutine(EnemyTurn());
        }

    }

    void PlayerTurn()
    {
        AttackButton.interactable = true;
        AbilityButton.interactable = true;
        PlayerAttack();
    }

    public void OnAttackButton()
    {
        if (battleStates != BattleStates.PlayerTurn)
            return;
        AttackButton.interactable = false;
        StartCoroutine(PlayerAttack());
    } 

    public void OnAbilityButton()
    {
        if(abilityCounter > 0)
        {
            abilityCounter--;
            AbilityButton.interactable = false;
            StartCoroutine(AbilityAttack());
        }
        else
        {
            Debug.Log("No Abilities left");
        }
    }
}
