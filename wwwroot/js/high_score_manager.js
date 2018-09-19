function HighScoreManager() {
    this.serviceUrl =  "https://localhost:5001/api/highscore";
}

function highScoreListener() {
        console.log("Current highscore is: " + this.responseText);
        return this.responseText;
}
  
HighScoreManager.prototype.getBestScore = function () {
    var request = new XMLHttpRequest();
    request.open('GET', this.serviceUrl, false);
    request.send(null);
    if (request.status === 200) {
        return parseInt(request.responseText, 10);
    }
    return 0;
};

HighScoreManager.prototype.setBestScore = function (score) {
    var request = new XMLHttpRequest();
    request.open("POST", this.serviceUrl, true);
    request.setRequestHeader("Content-type", "application/json");

    request.onreadystatechange = function() {
        if(this.readyState == XMLHttpRequest.DONE && this.status == 200) {
            console.log("New highscore is: " + this.responseText);
        }
    }

    request.send(score);
};