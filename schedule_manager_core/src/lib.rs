use serde::{Serialize, Deserialize};
use chrono::DateTime;
use chrono::NaiveTime;
use chrono::Local;

#[derive(Serialize, Deserialize)]
pub struct WorkHours {
    pub start: NaiveTime,
    pub end: NaiveTime,
}

impl WorkHours {
    pub fn new_hours(start:NaiveTime, end: NaiveTime) -> Self {
        WorkHours { start, end }
    }
}

#[derive(Serialize, Deserialize)]
pub struct WorkTask {
    pub task_name: String,
    pub arg: String,
    pub task_time: NaiveTime,
}

impl WorkTask {
    pub fn new_task(task_name: String, arg: String, task_time: NaiveTime) -> Self {
        WorkTask { task_name, arg, task_time }
    }
}

#[derive(Serialize, Deserialize)]
pub struct Event {
    pub event_name: String,
    pub arg: String,
    pub event_date_time: DateTime<Local>,
}

impl Event {
    pub fn new_event(event_name: String, arg: String, event_date_time: DateTime<Local>) -> Self{
        Event { event_name, arg, event_date_time }
    }
}