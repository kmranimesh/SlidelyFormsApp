import express from 'express';
import fs from 'fs';
import path from 'path';

const app = express();
const port = 3000;
const dbPath = path.join(__dirname, 'db.json');

app.use(express.json());

app.get('/ping', (req, res) => {
    res.send(true);
});

app.post('/submit', (req, res) => {
    const { name, email, phone, github_link, stopwatch_time } = req.body;
    const newSubmission = { name, email, phone, github_link, stopwatch_time };
    let submissions = [];
    if (fs.existsSync(dbPath)) {
        submissions = JSON.parse(fs.readFileSync(dbPath, 'utf-8'));
    }
    submissions.push(newSubmission);
    fs.writeFileSync(dbPath, JSON.stringify(submissions, null, 2));
    res.status(201).send(newSubmission);
});

app.get('/read', (req, res) => {
    const index = parseInt(req.query.index as string, 10);
    if (isNaN(index)) {
        return res.status(400).send('Invalid index');
    }
    const submissions = JSON.parse(fs.readFileSync(dbPath, 'utf-8'));
    if (index < 0 || index >= submissions.length) {
        return res.status(404).send('Submission not found');
    }
    res.send(submissions[index]);
});

app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}/`);
});
