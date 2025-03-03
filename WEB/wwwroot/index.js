
function displayResult(elementId, data)
{
    document.getElementById(elementId).textContent = JSON.stringify(data, null, 2);
}

async function getAllOrders()
{
    const response = await fetch('/api/v1/Team/teams', { method: "GET" });
    const data = await response.json();
    displayResult('orders-result', data);
}

async function createOrder()
{
    const name = document.getElementById('order-name').value;
    const typeBrigade = document.getElementById('order-type-brigade').value;

    const order = {
        name: name,
        typeBrigade: Number(typeBrigade)
    };
    console.log(order);
    const response = await fetch('/api/v1/Team/createTeam', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(order)
    });

    const data = await response.json();
    displayResult('create-order-result', data);
}

async function getAllAssignments()
{
    const response = await fetch('/api/v1/Assignments/assignments');
    const data = await response.json();
    displayResult('assignments-result', data);
}

async function assignOrderToBrigade()
{
    const orderId = document.getElementById('assignment-order-id').value;
    const brigadeId = document.getElementById('assignment-brigade-id').value;
    const description = document.getElementById('assignment-description').value;
    const assignmentDate = new Date().toISOString();
    const completionDate = document.getElementById('assignment-completion-date').value;
    const status = document.getElementById('assignment-status').value;
    const notes = document.getElementById('assignment-notes').value;
    const geologicalSurveys = [];
    const assignment = {
        description: description,
        assignmentDate: assignmentDate,
        completionDate: completionDate,
        status: Number(status),
        notes: notes,
        geologicalSurveys: geologicalSurveys,
        orderId: parseInt(orderId),
        brigadeId: parseInt(brigadeId)
    };

    const response = await fetch('/api/v1/Assignments/createAssignment', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(assignment)
    });

    const data = await response.json();
    displayResult('assign-order-result', data);
}

async function getAllReports()
{
    const response = await fetch('/api/v1/Request/requests');
    const data = await response.json();
    displayResult('reports-result', data);
}

async function createReport()
{
    const description = document.getElementById('report-description').value;
    const creationDate = new Date().toISOString();
    const status = "Pending";
    const assignments = [];
    const notes = document.getElementById('report-notes').value;

    const requestDTO = {
        id: id,
        description: description,
        creationDate: creationDate,
        status: Number(status),
        assignments: assignments,
        notes: notes,
    };

    const response = await fetch('/api/v1/Request/createRequest', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(requestDTO)
    });

    const data = await response.json();
    displayResult('create-report-result', data);
}

async function getMonthlyStatistics()
{
    const startDate = document.getElementById('statistics-start-date').value;
    const endDate = document.getElementById('statistics-end-date').value;
    const response = await fetch(`/api/v1/Statistics/statistic?start=${startDate}&end=${endDate}`);
    const data = await response.json();
    displayResult('statistics-result', data);
}