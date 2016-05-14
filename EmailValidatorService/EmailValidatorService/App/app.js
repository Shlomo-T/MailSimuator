
var app = angular.module("Main", []);
init = function () {
    $scope.users = "shlomo";
    cosole.log($scope.users);
};
   /* app.service("ApiService", function ApiService($http) {
        basePathUsers= "/api/users";
        basePathMessages= "/api/messages",


        this.getAllUsers = function () {
            $http.get(basePathUsers).then(function (response) {
                return response.data;
            });
               
        }
    });*/




    var MainCtrl = function ($scope, $http) {
        
        var onUserComplete = function (response) {
            $scope.users = response.Emails=[];
            $scope.users = response.data;
            $scope.selectedUser = $scope.users[0];
            $scope.LoadUserData = function () {
                console.log($scope.selectedUser);
                var su = $scope.selectedUser;
                $http.get("http://localhost:32145/api/messages/incoming?id=" + su).then(onIncomingComplete, onerror);
                $http.get("http://localhost:32145/api/messages/outgoing?id=" + su).then(onOutgoingComplete, onerror);

            }
            $scope.ShowIncoming=function(){
                if($scope.Incoming!=null){
                    $scope.showEmails=true;
                    $scope.Emails = $scope.Incoming;
                    if (!$scope.$digest) {
                        $scope.$apply();
                    }
                }
                else {
                    alert("No Incoming mails to this user");
                }
            }

            $scope.ShowOutgoing= function () {
                if ($scope.Outgoing != null) {
                    $scope.showEmails = true;
                    $scope.Emails = $scope.Outgoing;
                    if (!$scope.$digest) {
                        $scope.$apply();
                    }
                }
                else {
                    alert("No outgoing mails to this user");
                }
                console.log($scope.Outgoing);
            }

            $scope.GetOwner = function (mail) {
                if ($scope.Emails != null) {
                    $scope.showEmails = false;
                    $scope.TestedEmail = mail;
                    if (!$scope.$digest) {
                        $scope.$apply();
                    }
                }
                else {
                    alert("Failed to get all information about this emil");
                }
                console.log($scope.TestedEmail);
            }

            $scope.showEmails=true;
            console.log($scope.selectedUser);
            console.log($scope.Incoming);
            console.log($scope.Outgoing);

        }



        var onIncomingComplete = function (response) {
            $scope.Incoming = response.data;
            if ($scope.Incoming != undefined) {
                $scope.Emails = response.data;
                if (!$scope.$digest) {
                    $scope.$apply();
                }
                console.log("Emails:");
                console.log($scope.Emails);
                console.log($scope.users);


            }

        }

        var onOutgoingComplete = function (response) {
            $scope.Outgoing = response.data;
            console.log("Outgoing:");
            console.log($scope.Outgoing);

        }

        var onError = function (reason) {
            $scope.error = reason;
            console.log($scope.error);
        }

        $http.get("http://localhost:32145/api/users?testable=false").then(onUserComplete, onerror);

        //$scope.users=ApiService.getAllUsers();
    };
    var TableCtrl = function ($scope) {

    };
    app.controller("MainCtrl", MainCtrl);
    app.controller("TableCtrl", TableCtrl);
