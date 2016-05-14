var app = angular.module("MainApp", []);

app.service("userService", function ($http, $q) {
    var deffered = $q.defer();

    $http.get("http://localhost:32145/api/users?testable=true").then(function (data) {
        deffered.resolve(data);
    });
    this.getUser = function () {
        return deffered.promise;
    }
})

.controller("usersCtrl", function ($scope, userService) {
    var promise = userService.getUser();

    promise.then(function (data) {
        $scope.users = data.data;
        $scope.currUser = data.data[0];
        console.log($scope.users);
    });
})


function SelectUser($scope) {
    var userId = document.getElementById("userSelector").value;
    console.log(userId);
}
