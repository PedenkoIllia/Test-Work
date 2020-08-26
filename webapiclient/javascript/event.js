document.addEventListener("DOMContentLoaded", SetMaxLength)

GetData('http://localhost:5000')
  .then((data) => 
      printToRecordList(data)
  );

window.onload = function() {
    document.getElementById("formchange").onsubmit = async (e) => {
        e.preventDefault();

        var data = formToDictionary(e.target);
        if(data["id"]) 
            data["id"] = parseInt(data["id"], 10); //from form it has type string...
        else
            data["id"] = 0;

        PutData("http://localhost:5000", data)
            .then((record) => {
                if(!record.errors)
                    if(!record["IdProblem"])
                        changeRecord(record);
                    else
                        alert(record["IdProblem"]);
                else
                    printErrors(record.errors);
            });      
    }

    document.getElementById("formadd").onsubmit = async (e) => {
        event.preventDefault();

        var data = formToDictionary(e.target);
        PostData("http://localhost:5000", data)
            .then(record => {
                if(!record.errors)
                    addRecord(record)
                else 
                    printErrors(record.errors);
            }
        );
    }
}

function SetMaxLength () {
    var element = document.getElementById ("changevalue");
    element.maxLength = 3;
    element = document.getElementById ("value");
    element.maxLength = 3;
}

function GetRecordId(element) {
    var message = "Id записи: " + element.innerHTML + " - " + element.id;
    alert(message);
}

async function GetData(url = '') {
    const response = await fetch(url, {
      method: 'GET',
      mode: 'cors',
    });
    return await response.json();
  }

async function PutData(url = '', data = {}) {
    const response = await fetch(url, {
      method: 'PUT',
      mode: 'cors',  
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    });
    return response.json();
  }

async function PostData(url = '', data = {}) {
    const response = await fetch(url, {
      method: 'POST',
      mode: 'cors',
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    });
    return await response.json();
  }

async function printToRecordList(jsonObj) {
    jsonObj["records"].forEach(record => 
        addRecord(record)
    );
}

async function addRecord(record) {
    var recordList = document.getElementById("list");
    
    let span = document.createElement("span");

    let p = document.createElement("p");
    p.id = record["id"];
    p.className = "codename";
    p.innerHTML = record["code"] + " " + record["name"];

    span.append(p);
    recordList.append(span);

    p.addEventListener('click', function (event) {
        GetRecordId(p);
    });
}

async function changeRecord(record) {
    var element = document.getElementById(record["id"]);
    element.innerHTML = record["code"] + " " + record["name"];
}

function formToDictionary(form) {
    form = new FormData(form);
    var data = {};
    form.forEach(function(value, key){
        data[key] = value;
    });

    return data;
}

function printErrors(errors) {
    var problem = "";

    if(errors.Id)
        problem += errors.Id + '\n';
    if(errors.Code)
        problem += errors.Code + '\n';
    if(errors.Name)
        problem += errors.Name;

    if(problem != "")
        alert(problem);
    else
        console.log(errors);
}