# Bce.ExchangeRates: Cambios diarios de BCE

```C#
// A incluir:           
/using Bce.ExchangeRates.Net;


    public void BajarCambios()
    {  
         var rates = Manager.GetExchangeRates();

         foreach (var rate in rates.Items)
         {
             // hacer lo que se desee
         }            
     }

```
