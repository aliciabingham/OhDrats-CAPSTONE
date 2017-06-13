app.controller("BattleController", ["$scope", "$http", "$location", "$rootScope",
    function ($scope, $http, $location, $rootScope) {

        $scope.addOpponent = function () {
            console.log("you clicked submit on opponent");

            $http({
                method: 'POST',
                url: "api/opponent",
                data: { Name: $scope.opponentName }
            })
                .then(function (result) {
                    console.log("result=", result);
                });

            $http({
                method: 'POST',
                url: "api/battle",
                data: { OpponentName: $scope.opponentName, ShotsFired: $scope.shotsFired, Hits: $scope.shotsHit, Misses: $scope.shotsMissed, Gun: $scope.Gun, Score: $scope.shotsHit}
            })
                     .then(function (result) {
                         console.log("result from battle=", result);
                     });
            accuracyCounter();
        }

        function accuracyCounter() {
            var hits = $scope.shotsHit;
            var misses = $scope.shotsMissed;
            var total = $scope.shotsFired;
            var opponent = $scope.opponentName;
            var gun = $scope.Gun;
            var answer = ((hits / total) * 100);

            console.log(answer);

            $('#output').html(`<br><h4>You shot at ${opponent} ${total} times with your ${gun} gun. You missed ${misses} times, making your accuracy for this battle ${answer}%!</h4>`);
        };

         $scope.battleHistory = function() {
            $http({
                method: 'GET',
                url: 'api/battle/battlehistory'
            })
            .then(function (result) {
                $scope.displayHistory(result);
            })
         }

       $scope.displayHistory = function (result) {
           $('#battleHistoryOutput').html('');

           for (var i = 0; i < 15; i++) {
               var battleHistoryOpponentName = result.data[i].OpponentName;
               var battleHistoryShotsFired = result.data[i].ShotsFired;
               var battleHistoryShotsHit = result.data[i].Hits;
               var battleHistoryShotsMissed = result.data[i].Misses;
               var battleHistoryGun = result.data[i].Gun;

               $('#battleHistoryOutput').append(`<h4>You recently had a battle with <b>${battleHistoryOpponentName}</b>, in which you fired <b>${battleHistoryShotsFired}</b> shots, hit <b>${battleHistoryShotsHit}</b> times, missed <b>${battleHistoryShotsMissed}</b> times, and used the <b>${battleHistoryGun}</b> gun. <br><br></h4>`);           }        
         }
}
]);