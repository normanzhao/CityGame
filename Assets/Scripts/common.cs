using UnityEngine;
public static class common {

	public static string formatMoney(decimal amount){
        string[] suffixes = new string[]{"", "K", "M", "B", "T", "Quad", "Quint", "Sext", "Sept", "Oct", "Non", "Dec"};
        string returnString = System.Math.Round(amount,2).ToString();
        for(int x = 1; x < suffixes.Length; x++){
            if(amount > (decimal)Mathf.Pow(10, x * 3)){
                returnString = System.Math.Round((amount / (decimal)Mathf.Pow(10, x * 3)),2) + " " + suffixes[x];
            }
            else{
                break;
            }
        }
        return returnString;
    }

    public static string formatMoneyNoDec(decimal amount){
        string[] suffixes = new string[]{"", "K", "M", "B", "T", "Quad", "Quint", "Sext", "Sept", "Oct", "Non", "Dec"};
        string returnString = System.Math.Ceiling(amount).ToString();
        for(int x = 1; x < suffixes.Length; x++){
            if(amount > (decimal)Mathf.Pow(10, x * 3)){
                returnString = System.Math.Ceiling((amount / (decimal)Mathf.Pow(10, x * 3))) + " " + suffixes[x];
            }
            else{
                break;
            }
        }
        return returnString;
    }

    public static string formatTime(int seconds){
        int minutes = (int)Mathf.Floor(seconds / 60);
        if(seconds < 60){
            return string.Format("0 minutes and {0} seconds", new string[]{(seconds).ToString()});
        }
        return string.Format("{0} minutes and {1} seconds", new string[]{minutes.ToString(), (minutes % 60).ToString()});
    }
}
