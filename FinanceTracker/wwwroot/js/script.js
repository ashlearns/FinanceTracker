window.drawPieChart = function (labels, data) {
    const ctx = document.getElementById('pieChart');
    new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                label: 'Amount',
                data: data,
                backgroundColor: ['#28a745', '#dc3545', '#ffc107'],
                borderWidth: 1
            }]
        }
    });
};

window.drawBarChart = function (labels, data) {
    const ctx = document.getElementById('barChart');
    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Top Transactions',
                data: data,
                backgroundColor: '#007bff'
            }]
        }
    });
};
