module featureStepDefinitions

open TickSpec
open canopy

[<Given>]
let  ``I visit (.*)`` justEatUrl =
    start firefox
    url justEatUrl
      
[<Given>] 
let ``I enter the known postcode (.*)`` postcode = 
    "#postcode" << postcode
   
[<When>]     
let ``the search button is pressed`` () = 
    click "#searchRestaurants"
    
[<Then>]  
let ``a list of restuarants should be returned`` () =   
    "#restaurants tbody tr td" != ""
   
[<Then>] 
let ``the returned restaurants Name, Cuisine and Rating are displayed`` () =
    "#restaurants tbody tr td" *= "Monkeys" 
    "#restaurants tbody tr td" *= "Indian"
    "#restaurants tbody tr td" *= "5.16"
    