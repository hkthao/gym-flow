# Admin Dashboard

This is the frontend dashboard for the Gym Flow application. It is built with Vue 3 and Element Plus.

## Project Structure

The project is organized into modules, with each module representing a microservice. The modules are located in the `src/modules` directory.

Each module has the following structure:

-   `components`: Vue components specific to the module.
-   `router`: Vue Router configuration for the module.
-   `stores`: Pinia stores for the module.
-   `views`: Vue views for the module.
-   `tests`: Unit tests for the module.

## Unit Tests

The project is set up with Vitest for unit testing. However, the current tests are placeholders and do not provide meaningful coverage. Testing components that use Element Plus has proven to be complex and requires further investigation.

To run the tests:

```bash
npm run test:unit
```

To run the tests with coverage:

```bash
npm run test:coverage
```

## Adding a New Module

To add a new module, follow these steps:

1.  Create a new directory in `src/modules` with the name of the module.
2.  Create the `components`, `router`, `stores`, `views`, and `tests` directories inside the new module directory.
3.  Create the necessary files for the module (components, routes, store, etc.).
4.  Import the module's routes in `src/router/index.ts` and add them to the router configuration.
5.  Add a new item to the sidebar in `src/layouts/DashboardLayout.vue` to navigate to the new module.