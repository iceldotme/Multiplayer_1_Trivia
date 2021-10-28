var questionCounter = 0;
window.addEventListener('load', onPageLoaded);

function onPageLoaded() {
    setScore(-5);
}

/***************************************/
function clickYes() {
    let currentQuestion = document.getElementById("content").innerHTML;
    sendGet("api/WebApi/action/", "Yes", currentQuestion, checkAnswerResult);
    sendGet("api/WebApi/", "RandomQuestion", null, FillWithNewQuestion);

    questionCounter++;
}

function clickNo() {
    sendGet("api/WebApi/", "RandomQuestion", null, FillWithNewQuestion);
    questionCounter++;
}


/***************************************/
function FillWithNewQuestion(data) {
    document.getElementById("content").innerHTML = data;
}
function checkAnswerResult(data) {
    if (data == 'true') console.log("success");
    else console.log("failure");
}
function setScore(newValue) {
    document.getElementById("score").innerHTML = "Score is " + newValue;
}
function stopQuestion() {
    document.getElementById("no").hidden = true;
    document.getElementById("yes").hidden = true;
}


/***************************************/
function sendGet(apiUrl, serverFolder, info, onSuccess) {
    function UrlEncode(str) {
        str = str.replaceAll('?', 'XXX');
        str = str.replaceAll('.', 'YYY');
        str = encodeURIComponent(str);
        return str;
    }

    if (typeof info !== 'undefined' && info !== null) {
        info = UrlEncode(info);
        serverFolder += '/'
    } else {
        info = "";
        serverFolder += '/'
    }
    var url = apiUrl + serverFolder + info;
    sendGetWithUrl(url, onSuccess);
}
function sendGetWithUrl(url, onSuccess) {
    fetch(url).then(function (response) {
        if (response.status !== 200) {
            console.error('fetch returned not ok' + response.status, response);
        }
        else {
            response.json().then(function (data) {
                console.log(data);
                onSuccess(data);//Need to create this functions
            }).catch(err => {
                console.error("json exception " + err);
            })
        }
    }).catch(err => {
        console.error("url exception " + err);
    });
}


/***************************************/
function sendPost(apiUrl, optionsSelected) {
    fetch(apiUrl, {
        method: 'post',
        headers: {
            'Accept': 'application/json, text/plain, */*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(optionsSelected),
    })
        .then(function (response) {
            if (response.status !== 200) {
                console.error('fetch returned not ok' + response.status, response);
            }
            else {
                response.json().then(function (data) {
                    console.log('fetch returned ok', data);
                    onPostDataRecieved(data);//Need to create this functions
                }).catch(err => {
                    console.error("json parsing exception " + err);
                });
            }
        }).catch(err => {
            console.error("url exception " + err);
        });
}

function onPostDataRecieved(data) {
    document.getElementById("content").innerHTML = data;
}



