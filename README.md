# Bce.ExchangeRates: Cambios diarios de BCE

Utilice esta biblioteca para leer los cambio publicados en el Banco Central Europeo.

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
