document.forms["chartForm"].addEventListener("submit", e => {
    e.preventDefault();
    GetChartData(document.forms["chartForm"]);
});

async function GetChartData(form) {
    const a = form.elements["a"].value;
    const b = form.elements["b"].value;
    const c = form.elements["c"].value;
    const from = form.elements["rangeFrom"].value;
    const to = form.elements["rangeTo"].value;
    const step = form.elements["step"].value;

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
        console.log(chartData);
        CreateChart(chartData);
    }
    else {
        console.log("Не выполнился");
    }
}

function CreateChart(chartData) {
    let ctx = document.getElementById('myChart').getContext('2d');
    console.log(chartData.labels);
    console.log(chartData.points);
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