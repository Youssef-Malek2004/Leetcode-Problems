namespace Leetcode_Problems;

public class Stripe
{
    public List<string> calculate_merchant_fraud_score(List<string> transactions_list, List<string> rules_list, List<string> merchants_list)
    {
        var merchantsLength = merchants_list.Count;

        var result = new List<string>();

        for (int i = 0; i < merchantsLength; i++)
        {
            var merchantInfo = merchants_list[i].Split(",", 2);

            var currentScore = int.Parse(merchantInfo[1]);
            
            var multiplications = new List<int>();
        
            var additions = new Dictionary<string, List<int>>();
        
            var customersToHours = new Dictionary<string, Dictionary<int,List<int>>>();

            for (var j = 0; j < transactions_list.Count; j++)
            {
                var transaction = transactions_list[j].Split(",", 4);
                
                var rule = rules_list[j].Split(",", 4);

                // If it is the same merchant start doing your calculations
                if (transaction[0].Equals(merchantInfo[0]))
                {
                    // Multiplicity Calculation
                    if (int.Parse(transaction[1]) > int.Parse(rule[0]))
                    {
                        multiplications.Add(int.Parse(rule[1]));
                    }
                    
                    // Addition
                    if (additions.ContainsKey(transaction[2]))
                    {
                        additions[transaction[2]].Add(int.Parse(rule[2]));
                    }
                    else
                    {
                        additions.Add(transaction[2], [int.Parse(rule[2])]);
                    }
                    
                    //Last but not least
                    if (customersToHours.ContainsKey(transaction[2]))
                    {
                        if (customersToHours[transaction[2]].ContainsKey(int.Parse(transaction[3])))
                        {
                            customersToHours[transaction[2]][int.Parse(transaction[3])].Add(int.Parse(rule[3]));
                        }
                        else
                        {
                            customersToHours[transaction[2]].Add(int.Parse(transaction[3]), [int.Parse(rule[3])]);
                        }
                    }
                    else
                    {
                        var hours = new Dictionary<int, List<int>>();
                        
                        hours.Add(int.Parse(transaction[3]), [int.Parse(rule[3])]);
                        
                        customersToHours.Add(transaction[2], hours);
                    }
                }
            }

            // Multiplication Step
            foreach (var multiplication in multiplications)
            {
                currentScore *= multiplication;
            }
            
            // Addition Step
            foreach (var customer in additions)
            {
                if (customer.Value.Count < 3) continue;
                foreach (var value in customer.Value)
                {
                    currentScore += value;
                }
            }
            
            // Final Step
            foreach (var customer in customersToHours)
            {
                foreach (var hour in customer.Value)
                {
                    if (hour.Value.Count >= 3)
                    {
                        if (hour.Key >= 12 && hour.Key <= 17)
                        {
                            foreach (var penalty in hour.Value)
                            {
                                currentScore += penalty;
                            }
                        }
                        else if ((hour.Key >= 9 && hour.Key <= 12) || (hour.Key >= 18 && hour.Key <= 21))
                        {
                            foreach (var penalty in hour.Value)
                            {
                                currentScore -= penalty;
                            }
                        }
                    }
                }
            }

            var resultMid = merchantInfo[0] + "," + currentScore;
            
            result.Add(resultMid);
        }
        
        return result;
    }
}