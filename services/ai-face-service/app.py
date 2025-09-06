# ai-face-service/app.py
from fastapi import FastAPI
from logging_config import setup_logging
import logging
from prometheus_client import start_http_server, Counter

setup_logging()
logger = logging.getLogger(__name__)

app = FastAPI()

REQUEST_COUNT = Counter('app_requests_total', 'Total number of requests to the application')

@app.on_event("startup")
async def startup_event():
    logger.info("AI Face Service started")
    start_http_server(8000) # Start Prometheus HTTP server on port 8000

@app.get("/")
async def root():
    REQUEST_COUNT.inc() # Increment counter for each request
    logger.info("Root endpoint accessed")
    # Example of an error log
    try:
        # Simulate a face recognition failure
        raise ValueError("Face not recognized")
    except ValueError as e:
        logger.error("Face recognition failed", extra={'error': str(e), 'user_id': 'test_user'})
    return {"message": "Hello from AI Face Service"}

@app.get("/health")
async def health_check():
    return {"status": "ok"}