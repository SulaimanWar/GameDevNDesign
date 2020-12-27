using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wardrobe : MonoBehaviour
{
    [Header("Reward Position")]
    [SerializeField] private float xPosition = 2f;
    [SerializeField] private float yPosition = 2f;
    
    [SerializeField] private GameObject[] rewards;
    
    private bool canReward;
    private bool rewardDelivered;
    private Vector3 rewardRandomPosition;

    private Animator animator;
    private readonly int wardrobeOpenedParameter = Animator.StringToHash("Rewarded");

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (canReward)
            {
                RewardPlayer();
            }
        }
    }

    private void RewardPlayer()
    {
        if (canReward && !rewardDelivered)
        {
            animator.SetTrigger(wardrobeOpenedParameter);
            rewardRandomPosition.x = Random.Range(-xPosition, xPosition);
            rewardRandomPosition.y = Random.Range(-yPosition, yPosition);
            Instantiate(SelectReward(), transform.position + rewardRandomPosition, Quaternion.identity);

            rewardDelivered = true;
        }
    }

    private GameObject SelectReward()
    {
        int randomRewardIndex = Random.Range(0, rewards.Length);
        for (int i = 0; i < rewards.Length; i++)
        {
            return rewards[randomRewardIndex];
        }

        return null;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canReward = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canReward = false;
        }
}
}
