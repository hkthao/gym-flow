# ai-face-service/app.py
from fastapi import FastAPI
from logging_config import setup_logging
import logging

setup_logging()
logger = logging.getLogger(__name__)

app = FastAPI()

@app.on_event("startup")
async def startup_event():
    logger.info("AI Face Service started")

@app.get("/")
async def root():
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