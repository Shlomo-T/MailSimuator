var app = angular.module("MainApp", []);

app.service("emailsService", function ($http, $q) {
    var deffered = $q.defer();

    $http.get("http://localhost:32145/api/messages/incoming?id="+x).then(function (data) {
        deffered.resolve(data);
    });
    this.getEmails = function ( x) {
        return deffered.promise;
    }
})

.controller("emailsCtrl", function ($scope, userService) {
    var promise = userService.getEmails();

    promise.then(function (data) {
        $scope.Emails = data.data;
        console.log($scope.Emails);
    });
})



