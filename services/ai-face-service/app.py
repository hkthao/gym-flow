# ai-face-service/app.py
import logging
import json
from fastapi import FastAPI

# Custom JSON formatter
class JsonFormatter(logging.Formatter):
    def format(self, record):
        log_record = {
            "timestamp": self.formatTime(record, self.datefmt),
            "level": record.levelname,
            "message": record.getMessage(),
            "name": record.name,
            "pathname": record.pathname,
            "lineno": record.lineno,
            "funcName": record.funcName,
        }
        if record.exc_info:
            log_record["exc_info"] = self.formatException(record.exc_info)
        return json.dumps(log_record)

app = FastAPI()

# Configure logging
handler = logging.StreamHandler()
formatter = JsonFormatter()
handler.setFormatter(formatter)

# Get the root logger and add the handler
logger = logging.getLogger()
logger.setLevel(logging.INFO) # Set desired logging level
logger.addHandler(handler)

@app.get("/")
async def root():
    logger.info("Root endpoint accessed")
    return {"message": "Hello from AI Face Service"}