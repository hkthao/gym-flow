# AI Face Recognition Service BDD Tests

This service includes Behavior-Driven Development (BDD) tests using `pytest-bdd`.

## Directory Structure

- `features/`: Contains Gherkin `.feature` files that describe the desired behavior of the service.
- `tests/`: Contains Python test files (`test_*.py`) with step definitions that implement the scenarios defined in the `.feature` files.

## Running BDD Tests

To run the BDD tests for the AI Face Recognition Service, navigate to this directory (`services/ai-face-service`) and execute `pytest`:

```bash
cd services/ai-face-service
pytest
```

Ensure you have the necessary dependencies installed (e.g., `pytest`, `pytest-bdd`). You can install them via `pip`:

```bash
pip install -r requirements.txt
```
