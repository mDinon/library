import { from } from "rxjs";

const GET = (path: string, params?: URLSearchParams) => {
  const requestOptions = {
    method: "GET",
    headers: {},
  };

  return HttpRequestFactory(path, requestOptions, params);
};

const DELETE = (path: string, params?: URLSearchParams) => {
  const requestOptions = {
    method: "DELETE",
    headers: {},
  };

  return HttpRequestFactory(path, requestOptions, params);
};

const POST = (path: string, body: object, params?: URLSearchParams) => {
  const requestOptions = {
    method: "POST",
    headers: {
      "content-type": "application/json",
    },
    body: JSON.stringify(body),
  };

  return HttpRequestFactory(path, requestOptions, params);
};

const PUT = (path: string, body: object, params?: URLSearchParams) => {
  const requestOptions = {
    method: "PUT",
    headers: {
      "content-type": "application/json",
    },
    body: JSON.stringify(body),
  };

  return HttpRequestFactory(path, requestOptions, params);
};

const PATCH = (path: string, body: object, params?: URLSearchParams) => {
  const requestOptions = {
    method: "PATCH",
    headers: {},
    body: JSON.stringify(body),
  };

  return HttpRequestFactory(path, requestOptions, params);
};

const HttpRequestFactory = (
  path: string,
  requestOptions: object,
  params?: URLSearchParams
) => {
  return from(fetch(path, requestOptions).then(handleResponse));
};

const handleResponse = (response: Response) => {
  if (response.ok) {
    const contentType = response.headers.get("content-type");
    if (contentType?.includes("application/json")) {
      return response.json();
    } else {
      return response;
    }
  } else {
    throw new Error(response.statusText);
  }
};

export const HttpRequest = {
  GET,
  POST,
  PUT,
  DELETE,
  PATCH,
};
