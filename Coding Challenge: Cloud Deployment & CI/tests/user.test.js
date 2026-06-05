const request = require("supertest");
const app = require("../app");

describe("GET /api/users", () => {

  test("Should return users", async () => {

    const response = await request(app)
      .get("/api/users");

    expect(response.statusCode).toBe(200);

  });

});
