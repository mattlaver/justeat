

function Restaurant(name, cuisine, rating) {
    var self = this;

    self.Name = ko.observable(name);
    self.Cuisine = ko.observable(cuisine);
    self.Rating = ko.observable(rating);
}

function RestaurantList() {
    var self = this;

    self.restaurants = ko.observableArray([]);

    self.getRestaurants = function (postcode) {
        self.restaurants.removeAll();

        $.getJSON('/api/justeat?postcode=' + postcode, function (data) {
            $.each(data, function (key, value) {
                self.restaurants.push(new Restaurant(value.Name, value.Cuisine, value.Rating));
            });
        });
    }
}

restaurantViewModel = { restaurantListViewModel: new RestaurantList() }

$(document).ready(function () {
    ko.applyBindings(restaurantViewModel);
})