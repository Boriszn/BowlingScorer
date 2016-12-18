var bowlingGameModule = (function () {
    return {
        bowlingGameModel: { frames: ko.observableArray([]) },
        buildModel: function () {
            for (var i = 0; i < 10; i++) {
                this.bowlingGameModel.frames
                    .push({
                        score: ko.observable(0),
                        pinFirst: ko.observable(0),
                        pinSecond: ko.observable(0),
                        pinExtra: (i == 9/* aktivate extra step on 10 frame */ ? 0 : null)
                    });
            }
        },
        applyBindings: function () {
            var self = this;
            //Init change
            ko.bindingHandlers.changeSelectValue = {
                init: function(element, valueAccessor) {
                    $(element).change(function() {

                        self.getScore(JSON.stringify(ko.toJS(self.bowlingGameModel).frames),
                            function(resultViewModel) {
                                self.updateViewModel(resultViewModel);
                            });
                    });
                }
            };
            
            ko.applyBindings(this.bowlingGameModel);
        },
        getScore: function (stringifedData, proccessData) {
            $.ajax({
                url: "/Data/",
                type: "POST",
                data: stringifedData,
                dataType: "json",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    console.log(data);
                    proccessData(data);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert("Calculation error. Please provide valid data");
                }
            });
        },
        updateViewModel: function (resultViewModel) {
            var self = this;
            if (resultViewModel) {
                for (var frame in self.bowlingGameModel.frames()) {
                    self.bowlingGameModel.frames()[frame]
                        .score(resultViewModel[frame].Score);
                }
            }
        },
        init: function () {
            var self = this;

            self.buildModel();
            self.applyBindings();
            
            $("#calculateScoreBtn").on('click', function () {

                var gameViewModel = ko.toJS(self.bowlingGameModel);
                console.log(gameViewModel.frames);

                self.getScore(JSON.stringify(gameViewModel.frames),
                    function(resultViewModel) {
                        self.updateViewModel(resultViewModel);
                    });
            });
        }
    };
})();