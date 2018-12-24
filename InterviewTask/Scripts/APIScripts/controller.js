app.controller('APIController', function ($scope, APIService,$window,$http) {
    
    function GoHome(user) {
        $http({
            url: "/Home",
            params: user
        }).then(function (Users) {
            $window.location = '/Home/index';
        });
        
        //$window.location.assign(new URL{ "/Home/Index", user });
    }
    $scope.show = function (userId) {
        var show = APIService.Show(userId);
        show.then(function (requests) {
            $scope.requests = requests;
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        })
    };
    $scope.saveuser = function () {
        var user = {
            userName: $scope.userName,
            password: $scope.password
        };
        var saveuser = APIService.saveUser(user);
        saveuser.then(function (d) {
            GoHome(user);
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        })
    };
    $scope.LogIn = function () {
        var user = {
            userName: $scope.LogeduserName,
            password: $scope.Logedpassword
        };
        var ISloged = APIService.ISloged(user.userName, user.password);
        ISloged.then(function (user) {
            GoHome(user);
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        })
    };
    
    $scope.SaveRequest = function () {
        var Request = {
            requestTitle: $scope.Title,
            requestBody: $scope.Body
        };
        var Saved = APIService.SaveRequest(Request);
        Saved.then(function () {
            $window.location = '/client/index';
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        })
    };
    
    $scope.AssignUser = function (useid) {
        data = {
            userid: useid,
            roleid: $scope.role
        };
        var AssignUser = APIService.AssignUser(data);
        AssignUser.then(function () {
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        })
    };
    
    $scope.showUsers = function () {
        var showUsers = APIService.showUsers();
        showUsers.then(function (users) {
            $scope.Users = users;
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        })
    };
}

);
/////////////////
  





//(function () {
//    angular
//        .module('app')
//        .controller('controller', controller);

//    controller.$inject = ['$location'];

//    function controller($location) {
//        /* jshint validthis:true */
//        var vm = this;
//        vm.title = 'controller';

//        activate();

//        function activate() { }
//    }
//})();
