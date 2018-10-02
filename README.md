# Bce.ExchangeRates: Cambios diarios de BCE

Utilice esta biblioteca para leer los cambios publicados en el Banco Central Europeo.

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
