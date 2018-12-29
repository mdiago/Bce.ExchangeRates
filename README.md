# Bce.ExchangeRates: Cambios diarios de BCE

Utilice esta biblioteca para leer los cambios publicados en el Banco Central Europeo. Todos los días habiles el BCE publica sobre las 15:30 en su web los cambios oficiales de las divisas más importantes. 

```C#
// A incluir:           
// using Bce.ExchangeRates.Net;


    public void BajarCambios()
    {  
         var rates = Manager.GetExchangeRates();

         foreach (var rate in rates.Items)
         {
             // hacer lo que se desee
         }            
     }

```
