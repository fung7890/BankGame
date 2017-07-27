using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlink : MonoBehaviour
{

    // Use this for initialization
    public void solarLink()
    {
        Application.OpenURL("http://www.rbcroyalbank.com/business/financing/solar-panel-financing.html");
    }

    public void equipmentLink()
    {
        Application.OpenURL("http://www.rbcroyalbank.com/business/financing/business-equipment-leases.html");
    }

    public void insuranceLink()
    {
        Application.OpenURL("https://www.rbcinsurance.com/business-insurance/index.html");
    }

    //public void loansLink()
    //{
    //    Application.OpenURL("https://www.rbcinsurance.com/business-insurance/index.html");
    //}

    public void endOfGameLink()
    {
        Application.OpenURL("http://www.rbcroyalbank.com/growing-business/index.html");
    }

    public void marketingLink()
    {
        Application.OpenURL("http://www.rbcroyalbank.com/commercial/advice/general/marketing-for-small-business.html");
    }

}
