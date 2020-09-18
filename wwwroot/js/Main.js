document.forms["chartForm"].addEventListener("submit", e => {
    e.preventDefault();
    SubmitForm(document.forms["chartForm"]);
});

async function SubmitForm(form) {
    const a = form.elements["a"].value;
    const b = form.elements["b"].value;
    const c = form.elements["c"].value;
    const from = form.elements["rangeFrom"].value;
    const to = form.elements["rangeTo"].value;
    const step = form.elements["step"].value;

    if (IsFormValid(a,b,c,from,to,step)) {
        const response = await fetch("api/chart", {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                RangeFrom: parseInt(from),
                RangeTo: parseInt(to),
                Step: parseInt(step),
                A: parseInt(a),
                B: parseInt(b),
                C: parseInt(c)
            })
        });
        if (response.ok === true) {
            const chartData = await response.json();
            CreateChart(chartData);
        }
        else {
            console.log("Не выполнился");
        }
    }
}

function IsFormValid(a, b, c, from, to, step) {
    let isAllCorrect = true;
    if (a == "") {
        ShowMessage("aError", "Заполните поле");
        isAllCorrect = false;
    }
    if (b == "") {
        ShowMessage("bError", "Заполните поле");
        isAllCorrect = false;
    }
    if (c == "") {
        ShowMessage("cError", "Заполните поле");
        isAllCorrect = false;
    }
    if (from == "") {
        ShowMessage("rangeFromError", "Заполните поле");
        isAllCorrect = false;
    }
    if(to == "") {
        ShowMessage("rangeToError", "Заполните поле");
        isAllCorrect = false;
    }
    if (step == "") {
        ShowMessage("stepError", "Заполните поле");
        isAllCorrect = false;
    }

    if (from != "" && to != "") {
        if (from > to) {
            ShowMessage("rangeFromError", "Значение от должно быть меньше значения до");
            isAllCorrect = false;
        }
    }

    return isAllCorrect;
}

function ShowMessage(id, message) {
    document.querySelector("#" + id).textContent = message;
    document.querySelector("#" + id).classList.remove('d-none');
    setTimeout(function hide() {
        document.querySelector("#" + id).classList.add('d-none');
    }, 3000)
}


function CreateChart(chartData) {
    let ctx = document.getElementById('myChart').getContext('2d');
    let myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: chartData.labels,
            datasets: [{
                label: 'Iterations',
                data: chartData.points,
                backgroundColor: [
                    'rgba(0,0,0,0)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
            }],
        }
    });
}