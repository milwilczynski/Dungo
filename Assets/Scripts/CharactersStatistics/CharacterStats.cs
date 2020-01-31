
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;
    public int maxHealth = 100;
    private Animator animator;
    public static bool deadPlayed = false;
    public int currentHealth { get; private set;  }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0 && !deadPlayed)
        {
            deadPlayed = true;
            animator.SetTrigger("deadPlayer");
            animator.SetBool("deadowka", true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(25);
        }
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Die in some way
        Debug.Log(transform.name + " died.");
    }
    public void setCurrent(int recovery)
    {
        this.currentHealth += recovery;
    }

}
