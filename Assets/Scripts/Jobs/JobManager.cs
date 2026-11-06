using System.Collections.Generic;
using UnityEngine;

namespace OilSimulator
{
    public class JobManager : MonoBehaviour
    {
        private List<JobDefinition> generatedJobs;

        public void Awake()
        {
            generatedJobs = new List<JobDefinition>
            {
                new JobDefinition("First Run", "Deliver a crate to the local supply store.", 250f, 6f, 18f, 30f),
                new JobDefinition("Pressure Wash", "Clean the truck wash bay and parked equipment.", 180f, 2f, 15f, 12f),
                new JobDefinition("Starter Oil Sale", "Haul and sell a small amount of raw oil.", 420f, 11f, 24f, 28f, true)
            };

            GameData.Jobs.Clear();
            GameData.Jobs.AddRange(generatedJobs);
        }

        public JobDefinition GetCurrentJob(int index)
        {
            if (generatedJobs == null || generatedJobs.Count == 0)
            {
                return null;
            }

            return generatedJobs[Mathf.Clamp(index, 0, generatedJobs.Count - 1)];
        }

        public void CompleteJob(JobDefinition job)
        {
            if (job == null)
            {
                return;
            }

            GameData.Cash += job.Payout;
            GameData.PlayerLevel += 1;
            Debug.Log($"Completed job: {job.Title} | Earnings: ${job.Payout}");
        }
    }
}
